using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillionDollarAds.Control
{
    public class SearchHandler
    {
        public static SimpleFSDirectory dir = new SimpleFSDirectory(new System.IO.DirectoryInfo("../../LuceneDocuments"), null);
        public static List<Product> allProducts;

        public static void createIndex()
        {
            allProducts = new List<Product>();
            allProducts = Database.getAllProducts();

            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            IndexWriter writer = new IndexWriter(dir, analyzer, new IndexWriter.MaxFieldLength(1000));
            writer.DeleteAll();
            writer.SetSimilarity(new DefaultSimilarity());


            //Iterate in dataset 
            foreach (Product product in allProducts)
            {
                //Use Lucene Document for assign fields
                Document document = new Document();

                //Adding the fields in the document
                //Dont analyze category_id because it doesnt matter in the search
                document.Add(new Field("ad_title", product.Title, Lucene.Net.Documents.Field.Store.YES,
                                                                    Lucene.Net.Documents.Field.Index.ANALYZED,
                                                                    Lucene.Net.Documents.Field.TermVector.YES));
                document.Add(new Field("ad_id", product.Id.ToString(), Lucene.Net.Documents.Field.Store.YES,
                                                                    Lucene.Net.Documents.Field.Index.ANALYZED,
                                                                    Lucene.Net.Documents.Field.TermVector.YES));
                document.Add(new Field("ad_desc", product.Desc, Lucene.Net.Documents.Field.Store.YES,
                                                                    Lucene.Net.Documents.Field.Index.ANALYZED,
                                                                    Lucene.Net.Documents.Field.TermVector.YES));


                //add the documents in the writer
                writer.AddDocument(document);

            }

            //Closing the writer -- IF writer remains open the search cant be completed
            writer.Dispose();
        }

        public static List<Document> searchViaTextInTitle(string text,ListView listview)
        {
            //clear the list
            listview.Items.Clear();

            //make the search in the indexed file
            //List<Document> list = null;
            List<Document> list = doSearch(text);
            Document[] arr = list.ToArray();
            
            if (list == null)
                return null;

            return list;
        }

        private static List<Document> doSearch(string text)
        {
            //string text = RemoveControlCharsFromString(textSearch);
            if (text == null || text == "" || text.Contains('\n') || text.Contains('\t') || text.Contains('\r') || text.Contains('\b'))
                return null;
            //The array-list of title strings for the matching results
            List<Document> list = new List<Document>();

            //The IndexReader reads the index table -- opens the directory(IN MEMORY)
            IndexReader reader = IndexReader.Open(dir, true);
            //The indexSearcher is used to search for matches
            IndexSearcher searcher = new IndexSearcher(reader);
            searcher.SetDefaultFieldSortScoring(true, false);
            //Similarity -- relevence
            searcher.Similarity = new DefaultSimilarity();
            //The analyzer -- Maybe it has something to do with the relevence
            StandardAnalyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);


            MultiFieldQueryParser queryParser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, new string[] { "ad_id", "ad_title","ad_desc" }, analyzer);
            //The queryParser defines which fields are to be used for the search


            //True so we can use wildcards in the search *
            queryParser.AllowLeadingWildcard = true;
            //Used when searching now it matches results if the hit has one of the words 
            //example: "the house" will match only in text with both words
            queryParser.DefaultOperator = QueryParser.OR_OPERATOR;
            //A query is being created with the given text
            
            Query query = queryParser.Parse(text);


            TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);
            searcher.Search(query, collector);
            ScoreDoc[] matches = collector.TopDocs().ScoreDocs;


            //Itereate in matches array 
            foreach (ScoreDoc item in matches)
            {
                int id = item.Doc;
                //search by id in the index table -- very fast
                Document doc = searcher.Doc(id);
                //We add the document to the list
                list.Add(doc);

            }

            //the list is always with order by score
            return list;
        }
    }
}
