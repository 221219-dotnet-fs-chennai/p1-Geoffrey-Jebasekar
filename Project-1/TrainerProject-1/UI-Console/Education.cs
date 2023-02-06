﻿//using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BusinessLogic;

namespace UI_Console
{
    public class Education : IMenu
    {
        
        public Education() { }
        static Trainer_Education education = new Trainer_Education();

        Validation validation = new Validation();
        IEFRepo repo = new TrainerEFRepo();
        string val = Login.PassEmail();
        
        
        public void Display()
        {
            Console.WriteLine("Trainer's Education Details");
            
            Console.WriteLine("Hey ------------------ " + val);
            education.emailid = val;
            Console.WriteLine("[7] Percentage - " + education.percentage);
            Console.WriteLine("[6] End Year - " + education.endYear);
            Console.WriteLine("[5] Start Year - " + education.startYear);
            Console.WriteLine("[4] Stream - " + education.stream);
            Console.WriteLine("[3] Institute Name - " + education.instituteName);
            Console.WriteLine("[2] Education Type - " + education.educationType);
            
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    return "AddDetails";
                case "1":
                    
                        try
                        {
                            Console.WriteLine("Adding Trainer Eduction");

                            education.emailid = val;
                            repo.AddE(education);
                            
                            Console.WriteLine("Successfully added Education");
                            return "AddDetails";
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Sorry-----Try Adding Again");
                        Console.WriteLine(ex.Message);
                            
                        }
                        return "Education";
                    
                    

                case "2":
                    
                    Console.WriteLine("Enter your Education type");
                    education.educationType = Console.ReadLine();
                    return "Education";
                case "3":
                    
                    Console.WriteLine("Enter your Institute name");
                    education.instituteName = Console.ReadLine();
                    return "Education";
                case "4":
                    
                    Console.WriteLine("Enter your Stream");
                    education.stream = Console.ReadLine();
                    return "Education";
                case "5":
                    Console.WriteLine("Enter your Start Year");
                    education.startYear = Console.ReadLine();
                    return "Education";
                case "6":
                    Console.WriteLine("Enter your End Year");
                    education.endYear = Console.ReadLine();
                    return "Education";
                case "7":
                    Console.WriteLine("Enter your Percentage in the specified format");
                    Console.WriteLine("For eg: 92% or 92.4%");
                    
                    string p = Console.ReadLine();
                    if(p!=null)
                    {
                        bool percentage = validation.Percentage(p);
                        if(percentage)
                        {
                            education.percentage = p;
                        }
                        else
                        {
                            Console.WriteLine("Please add percentage in the spcified format");
                        }

                    }
                    
                    return "Education";
                default:
                    Console.WriteLine("Enter a valid response");
                    return "Education";
                        

            }
            
        }
    }
}
