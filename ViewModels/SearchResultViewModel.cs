using System.Collections.Generic;
//Add Using MyNamespace.Models/MyNamespace.ViewModels
using SearchExampleMVC.Models;

namespace SearchExampleMVC.ViewModels
{
    public class SearchResultViewModel
    {
        //Initialize the viewModel
        public SearchResultViewModel()
        {
            //Initialize each list
            //MyList = new List<T>();
            Categories = new List<Category>();
            Products = new List<Product>();
            NewsPosts = new List<NewsPost>();
        }
        //SearchString for for displaying the string on the Search view
        public string SearchString { get; set; }
        //Add list for every table that needs to be searched in
        //Public Virtual List<T> MyModels { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<NewsPost> NewsPosts { get; set; }
    }
    public static class Search
    {
        /// <summary>
        /// Method returns viewModel with List<T> of results including searchString
        /// </summary>
        /// <param name="searchString">String what you need to search for</param>
        /// <param name="context">ApplicationDbContext</param>
        /// <returns>viewModel with List<T> of results including searchString</returns>
        public static SearchResultViewModel SearchResult(string searchString, ApplicationDbContext context)
        {
            //Insert Context
            ApplicationDbContext db = context;
            SearchResultViewModel searchResult = new SearchResultViewModel();
            searchString = searchString.ToLower();
            //Foreach table you want to search in add a foreach
            //foreach (var item in db.MyTable)
            //{
            //    if (item.MyProperty1.Contains(searchString) || item.MyProperty2.Contains(searchString))
            //    {
            //        searchResult.Products.Add(item);
            //    }
            //}
            foreach (var item in db.Products)
            {
                //foreach property you want to compare you and a new OR statement
                if (item.Name.ToLower().Contains(searchString) || item.Description.ToLower().Contains(searchString))
                {
                    //add item to the list
                    searchResult.Products.Add(item);
                }
            }
            foreach (var item in db.Categories)
            {
                //foreach property you want to compare you and a new OR statement
                if (item.Name.ToLower().Contains(searchString))
                {
                    //add item to the list
                    searchResult.Categories.Add(item);
                }
            }
            foreach (var item in db.NewsPosts)
            {
                //foreach property you want to compare you and a new OR statement
                if (item.Name.ToLower().Contains(searchString) || item.Content.ToLower().Contains(searchString))
                {
                    //add item to the list
                    searchResult.NewsPosts.Add(item);
                }
            }
            return searchResult;
        }
    }

}