using System;
using System.Collections.Generic;
using System.Linq;
using EFGetStarted;

namespace SchoolCourse
{
    internal class Program
    {
        private static void Main()
        {
            using var db = new Context();
            var modelName = "CG11";
            
            // Remove all records before reseeding
            db.RemoveRange(db.GarageDoorModels);
            db.RemoveRange(db.Sections);
            
            // Add Seeder Data (this would come from CSV)
            
            db.Add(new Section
            {
                SectionName = "title",
                Key = "complete_title"
            });
            
            db.Add(new Section
            {
                SectionName = "specifications",
                Key = "complete_specifications"
            });
            
            db.Add(new GarageDoorModel
            {
                ModelName = modelName,
                WindCode = "W0", 
                Layout = "Complete"
            });
            
            db.SaveChanges();
            
            // Add Sections to Gdm from list
            //"CG11", "W0", "Complete", "complete_title, complete_specifications" -> list
            
            // Parse csv file
            var parser = new CsvParser();
            parser.ParseCsv("/Users/tblevins/Projects/Tutorials/SchoolCourse/some.csv", "quadruple");
            
            // Loop through result            
            foreach (var (model, windcode, layout, section_keys) in parser.CsvQuadruples)
            {
                var sections_to_save = new List<Section>();
            
                // get GDM 
                var gdm = db.GarageDoorModels.First(g => g.ModelName == model && g.WindCode == windcode && g.Layout == layout);
                
                //
                foreach (var key in section_keys)
                {
                    // find section from csv file key
                    var section = db.Sections.First(s => s.Key == key.Trim());
                    
                    // add section to list of sections
                    sections_to_save.Add(section);
                }
                // save sections as a relationship to gdm
                gdm.Sections = sections_to_save;
            }
            
            db.SaveChanges();
            
            // Read
            var new_gdm = db.GarageDoorModels.First(g => g.ModelName == modelName);
            Console.WriteLine(new_gdm.Sections);
            foreach (var VARIABLE in new_gdm.Sections)
            {
                Console.WriteLine(VARIABLE.Key);
            }
            
        }
    }
}
