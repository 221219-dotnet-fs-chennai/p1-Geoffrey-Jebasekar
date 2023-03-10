//using Data;
using BusinessLogic;
using EntityLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Console
{
    public class EditExperience
    {
        
        
        public EditExperience(string emailid) 
        {
            Mapper mapper = new Mapper();
            TutorAppContext context= new TutorAppContext();
            bool repeat = false;
            Console.WriteLine("Enter the Company name and title which experience details you want to edit");
            string companyName = Console.ReadLine();
            string title = Console.ReadLine();
            Trainer_Companies experience = new Trainer_Companies();
            IEFRepo repo = new TrainerEFRepo();
           
            var editExp = context.Companies;
            var editExpDet = (
                                from exp in editExp
                                where exp.Emailid == emailid && exp.CompanyName == companyName && exp.Title == title
                                select exp
                );
            

            if (!editExpDet.IsNullOrEmpty())
            {
                foreach(var exp in editExpDet)
                {
                    experience.id = exp.Id;
                    experience.companyName = exp.CompanyName;
                    experience.title = exp.Title;
                    experience.location = exp.Location;
                    experience.experience = exp.Experience;

                }
                repeat = true;


            }
            else
            {
                Console.WriteLine("Entered Company name or title does not exist in your profile");

            }

            while (repeat)
            {
                //Console.Clear();
                Console.WriteLine("Hey-----------------------------" + emailid);
                Console.WriteLine("Update your experience details and verify your changes");
                Console.WriteLine("[5] Experience in years - " + experience.experience );
                Console.WriteLine("[4] Location - " + experience.location);
                Console.WriteLine("[3] Title - " + experience.title);
                Console.WriteLine("[2] Company name - " + experience.companyName);

                Console.WriteLine("[1] Save");
                Console.WriteLine("[0] Go Back");
                Console.WriteLine("Enter your choice");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        repeat = false;
                        break;
                    case "1":

                        
                        experience.emailid = emailid;
                        repo.UpdateExperience(experience);
                      
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine("Enter your new Company name");
                        experience.companyName = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter your new Title");
                        experience.title = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter your new Location");
                        experience.location = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Enter your new experience in years");
                        experience.experience = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Enter a valid response");

                        break;
                }





            }
        }
    }
}
