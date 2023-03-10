using TrainerDet = EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using EntityLayer.Entities;
using Microsoft.Data.SqlClient;
using Azure;

namespace EntityLayer
{
    public class TrainerEFRepo : IEFRepo
    {
        TrainerDet.TutorAppContext context;

        public TrainerEFRepo(TrainerDet.TutorAppContext _context)
        {
            context = _context;
        }

        public void Add(TrainerDet.Signup signup)
        {
            context.Signups.Add(signup);
            context.SaveChanges();
        }

        public void AddC(TrainerDet.Company experience)
        {
            context.Companies.Add(experience);
            context.SaveChanges();
        }

        public void AddE(TrainerDet.Education education)
        {
            
            context.Educations.Add(education);
            context.SaveChanges();
        }

        public void AddL(TrainerDet.Login login)
        {
            context.Logins.Add(login);
            context.SaveChanges();
        }

        public void AddSk(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
        }

        public void DeleteAccount(string email)
        {
            var delete1 = context.Signups.Where(del => del.EmailId == email ).FirstOrDefault();
            //var delete2 = context.Logins.Where(del => del.Emailid == email).FirstOrDefault();
            try
            {
                if (delete1 != null)
                {
                    context.Signups.Remove(delete1);
                    //context.Logins.Remove(delete2);
                    context.SaveChanges();
                    
                }
                //if(delete2!=null)
                //{
                //    context.Logins.Remove(delete2);
                //    context.SaveChanges();
                //}
                Console.WriteLine("Trainer account deleted successfully");

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public TrainerDet.Education DeleteEducation(string email, string educationType)
        {
            var delete = context.Educations.Where(del => del.Emailid == email && del.EducationType == educationType).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Educations.Remove(delete);
                    context.SaveChanges();
                    Console.WriteLine("Education deleted successfully");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return delete;
            
        }

        public TrainerDet.Company DeleteExperience(string email, string companyName, string title)
        {
            var delete = context.Companies.Where(del => del.Emailid == email && del.CompanyName == companyName && del.Title == title).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Companies.Remove(delete);
                    context.SaveChanges();
                    //Console.WriteLine("Education deleted successfully");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return delete;

        }

       

        public TrainerDet.Skill DeleteSkill(string email, string skill)
        {
            var delete = context.Skills.Where(del => del.Emailid == email && del.Skill1 == skill).FirstOrDefault();
            try
            {
                if (delete != null)
                {
                    context.Skills.Remove(delete);
                    context.SaveChanges();
                    Console.WriteLine("Education deleted successfully");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return delete;
        }
        public IEnumerable<Trainer_Signup> GetTrainer(string email)
        {
            var signup = context.Signups;
            var trainerDet = (from tr in signup
                              where tr.EmailId == email
                              select new Trainer_Signup()
                              {
                                  firstname = tr.Firstname,
                                  lastname = tr.Lastname,
                                  emailId = tr.EmailId,
                                  age = tr.Age,
                                  phoneno = tr.Phoneno,
                                  city = tr.City




                              });
            return trainerDet.ToList();

        }

        public List<Trainer_Signup> GetAllTrainers()
        {
            var signup = context.Signups;
            var trainerDet = (from tr in signup
                              select new Trainer_Signup()
                              {
                                  firstname = tr.Firstname,
                                  lastname = tr.Lastname,
                                  emailId = tr.EmailId,
                                  age = tr.Age,
                                  phoneno = tr.Phoneno,
                                  city = tr.City




                              });
            return trainerDet.ToList();
        }

        public IEnumerable<Trainer_Signup> GetTrainerByAge(int age)
        {
            var signup = context.Signups;
            var trainerDet = (from tr in signup
                              where tr.Age >= age
                              select new Trainer_Signup()
                              {
                                  firstname = tr.Firstname,
                                  lastname = tr.Lastname,
                                  emailId = tr.EmailId,
                                  age = tr.Age,
                                  phoneno = tr.Phoneno,
                                  city = tr.City




                              });
            return trainerDet.ToList();
        }

        public IEnumerable<Trainer_Signup> GetTrainerByLocation(string location)
        {
            var signup = context.Signups;
            var trainerDet = (from tr in signup
                              where tr.City == location
                              select new Trainer_Signup()
                              {
                                  firstname = tr.Firstname,
                                  lastname = tr.Lastname,
                                  emailId = tr.EmailId,
                                  age = tr.Age,
                                  phoneno = tr.Phoneno,
                                  city = tr.City




                              });
            return trainerDet.ToList();
        }

        public IEnumerable<Trainer_Companies> GetTrainersCompanies(string email)
        {
            var experience = context.Companies;
            var trainerExpDet = (
                                   from tr in experience
                                   where tr.Emailid == email
                                   select new Trainer_Companies()
                                   {
                                       emailid = tr.Emailid,
                                       companyName = tr.CompanyName,
                                       title = tr.Title,
                                       location = tr.Location,
                                       experience = tr.Experience
                                   }
                );
            return trainerExpDet.ToList();
        }
        public IEnumerable<Trainer_Companies> GetTrainersCompanies(string email, string exp, string title)
        {
            var experience = context.Companies;
            var trainerExpDet = (
                                   from tr in experience
                                   where tr.Emailid == email && tr.CompanyName == exp && tr.Title == title
                                   select new Trainer_Companies()
                                   {
                                       emailid = tr.Emailid,
                                       companyName = tr.CompanyName,
                                       title = tr.Title,
                                       location = tr.Location,
                                       experience = tr.Experience
                                   }
                );
            return trainerExpDet.ToList();
        }
        public IEnumerable<Trainer_Education> GetTrainersEducation(string email)
        {
            var education = context.Educations;
            var trainerEduDet = (
                                    from tr in education
                                    where tr.Emailid == email
                                    select new Trainer_Education()
                                    {
                                        emailid = tr.Emailid,
                                        educationType = tr.EducationType,
                                        instituteName = tr.InstituteName,
                                        stream = tr.Stream,
                                        startYear = tr.StartYear,
                                        endYear = tr.EndYear,
                                        percentage = tr.Percentage


                                    });

            return trainerEduDet.ToList();
        }
        //IEnumerable<Trainer_Education> GetTrainersEducation(string email, string edu)
        //{
        //    var education = context.Educations;
        //    var trainerEduDet = (
        //                            from tr in education
        //                            where tr.Emailid == email && tr.EducationType == edu
        //                            select new Trainer_Education()
        //                            {
        //                                emailid = tr.Emailid,
        //                                educationType = tr.EducationType,
        //                                instituteName = tr.InstituteName,
        //                                stream = tr.Stream,
        //                                startYear = tr.StartYear,
        //                                endYear = tr.EndYear,
        //                                percentage = tr.Percentage


        //                            });

        //    return trainerEduDet.ToList();
        //}
        IEnumerable<Trainer_Education> IEFRepo.GetTrainersEducation(string email, string edu)
        {
            var education = context.Educations;
            var trainerEduDet = (
                                    from tr in education
                                    where tr.Emailid == email && tr.EducationType == edu
                                    select new Trainer_Education()
                                    {
                                        emailid = tr.Emailid,
                                        educationType = tr.EducationType,
                                        instituteName = tr.InstituteName,
                                        stream = tr.Stream,
                                        startYear = tr.StartYear,
                                        endYear = tr.EndYear,
                                        percentage = tr.Percentage


                                    });

            return trainerEduDet.ToList();
        }
        public IEnumerable<Trainer_Skills> GetTrainersSkills(string email)
        {
            var skills = context.Skills;
            var trainerskillDet = (
                                   from tr in skills
                                   where tr.Emailid == email
                                   select new Trainer_Skills()
                                   {
                                       emailid = tr.Emailid,
                                       skill = tr.Skill1,
                                       profeciencyInSkill = tr.Profeciency
                                   });
            return trainerskillDet.ToList();
            
        }

        public IEnumerable<Trainer_Skills> GetTrainersSkills(string email, string skill)
        {
            var skills = context.Skills;
            var trainerskillDet = (
                                   from tr in skills
                                   where tr.Emailid == email && tr.Skill1 == skill
                                   select new Trainer_Skills()
                                   {
                                       emailid = tr.Emailid,
                                       skill = tr.Skill1,
                                       profeciencyInSkill = tr.Profeciency
                                   });
            return trainerskillDet.ToList();

        }

        public IEnumerable<Trainer_Login> IsValidLogin(string email, string pass)
        {
            var valid = context.Logins;
            var trainer = (from tr in valid
                            where tr.Emailid == email && tr.Password == pass
                            select new Trainer_Login()
                            {
                                emailId= tr.Emailid,
                                password = tr.Password
                            }
                            );
            return trainer.ToList();
        }

        public Education UpdateEducation(string email,string educationType)
        {
            return context.Educations.Where(edu => edu.Emailid == email && edu.EducationType == educationType).FirstOrDefault();
        }

        public Education UpdateEducation(Education _education)
        {
            context.Educations.Update(_education);
            context.SaveChanges();
            return _education;
        }

        public Company UpdateExperience(string email, string companyName, string title)
        {
            return context.Companies.Where(exp => exp.Emailid == email && exp.CompanyName == companyName && exp.Title == title).FirstOrDefault();
      
        }


        public Company UpdateExperience(Company _experience)
        {
            context.Companies.Update(_experience);
            context.SaveChanges();
            return _experience;
        }

        public Signup UpdateProfile(string email)
        {
            return context.Signups.Where(sg => sg.EmailId == email).FirstOrDefault();
        }

        public Signup UpdateProfile(Signup _signup)
        {
            context.Signups.Update(_signup);
            context.SaveChanges();
            return _signup;
        }

        public Skill UpdateSkill(string email, string skill)
        {
            return context.Skills.Where(sk => sk.Emailid == email && sk.Skill1 == skill).FirstOrDefault();
        }
        public Skill UpdateSkill(Skill _skill)
        {
            context.Skills.Update(_skill);
            context.SaveChanges();
            return _skill;
        }

        
    }
}
