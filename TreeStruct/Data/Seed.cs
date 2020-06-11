using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStruct.Models;

namespace TreeStruct.Data
{
    public class Seed
    {
        public static void SeedCategories(Context context)
        {
            if (!context.Categories.Any())
            {
                var catData = System.IO.File.ReadAllText("Data/CategoriesSeed.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(catData);

                foreach (var cat in categories)
                    context.Categories.Add(cat);

                context.SaveChanges();
            }
        }
    }
}
