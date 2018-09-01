using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAd;

namespace my_cv
{
    class Program
    {
        static void Main(string[] args)
        {
            applicant applicant1 = new applicant() { name = "amr rizk", Email = "cutecena@hotmail.com", Phonenumber = "00201114566722" };


            List<skill> myskills = new List<skill> {
                new skill () {SkillName = "ASP.NET", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "ASP.NET MVC", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "C #", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "Minimum 3 years experience", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Talking and writing Danish", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Relevant Education from KU, ITU or similar", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Takes Responsibility for Own Projects from Ide to Implementation", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Entity Framework", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "SQL", SkillLevel = SkillLevel.Pro, SkillCategory =skillcategory.Programming},

                new skill () {SkillName = "HTML / CSS", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "jQuery", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "Backend", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.Programming},

                new skill () {SkillName = "Frontend", SkillLevel = SkillLevel.Pro, SkillCategory =skillcategory.Programming},

                new skill () {SkillName = "Trives in a young and dynamic environment", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Curious and Learning", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Enjoy working closely with other developers and claimants", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Want to work in a small .NET team with senior and junior developers", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Has humor and lots of good mood", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Preferring delicious food from a canteen to boring food packages", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

                new skill () {SkillName = "Looking forward to nice social events with colleagues", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta}




            };


            string addmotivation = "freelancer web developer with experience, project samples on github:github.com/amrahmedrizk";


            JobApplication jobapp = new JobApplication(applicant1, addmotivation, myskills);
            Console.WriteLine(jobapp.ApplicationAnalysis());
        }
    }
}
 

//using system;

//using System.Text;

 

namespace JobAd

{
    using JobAd;
    using System.Collections;
    using System.Collections.Generic;

    using System.Linq;



    public class JobApplication

    {

        public applicant Applicant { get; set; }

        public string AdditionalMotivation { get; set; }

        public List<skill> Skills { get; set; }

        public const string ContactPersonAt3 = "Steffen Jørgensen, + 453120XXXX ";

        public const string FormattedVersionWithSyntaxHighlighting = "http://pastebin.com/jXuj19F2";



        public JobApplication(applicant applicant, String additionalMotivation, List<skill> skills)

        {

            Applicant = applicant;

            AdditionalMotivation = additionalMotivation;

            Skills = skills;

        }



        public string ApplicationAnalysis()

        {

            int score = JobApplicantAwesomenessLevel();

            StringBuilder sb = new StringBuilder(string.Format("{0} scores {1} awesomeness point", this.Applicant.name, score));

            if (!string.IsNullOrEmpty(AdditionalMotivation))

            {

                sb.Append(Environment.NewLine);

                sb.Append(string.Format("In addition to the above score, {0} also has the following motivation for the appointment: {1}", Applicant.name, AdditionalMotivation));

            }
            return sb.ToString();

        }



        ///

        /// Call to get applicant awesomeness level. The higher score the better.

        ///

        private int JobApplicantAwesomenessLevel()

        {

            int applicantAwesomenessLevel = 0;



            bool isQualified = ApplicantHasAllRequiredSkills();

            if (isQualified)

            {

                applicantAwesomenessLevel = 10;

                applicantAwesomenessLevel += CountNiceToHaveSkills();

                applicantAwesomenessLevel += MetaSkillBonus();

            }

            return applicantAwesomenessLevel;

        }



        private Boolean ApplicantHasAllRequiredSkills()

        {

            List<skill> requiredSkills = new List<skill> {

new skill () {SkillName = "ASP.NET", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "ASP.NET MVC", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "C #", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "Minimum 3 years experience", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Talking and writing Danish", SkillLevel = SkillLevel.Pro, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Relevant Education from KU, ITU or similar", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Takes Responsibility for Own Projects from Ide to Implementation", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta}

};

            foreach (skill skill in requiredSkills)

            {

                bool hasSkill = (from relevantSkill in this.Skills

                                 where relevantSkill.SkillName == skill.SkillName

                                 && (relevantSkill.SkillLevel == SkillLevel.Average || relevantSkill.SkillLevel == SkillLevel.Pro)

                                 select relevantSkill).Any();

                if (hasSkill)

                {
                    continue;

                }

                return false;

            }

            return true;

        }



        private int CountNiceToHaveSkills()

        {

            List<skill> niceToHaveSkills = new List<skill>()

{

new skill () {SkillName = "Entity Framework", SkillLevel = SkillLevel.Beginner, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "SQL", SkillLevel = SkillLevel.Beginner, SkillCategory =skillcategory.Programming},

new skill () {SkillName = "Unit testing", SkillLevel = SkillLevel.Beginner, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "Dependency Injection", SkillLevel = SkillLevel.Beginner, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "Agile Development (Scrum)", SkillLevel = SkillLevel.Beginner, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "HTML / CSS", SkillLevel = SkillLevel.Beginner, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "jQuery", SkillLevel = SkillLevel.Beginner, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "Backend", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.Programming},

new skill () {SkillName = "Frontend", SkillLevel = SkillLevel.Average, SkillCategory =skillcategory.Programming}

};


            return (from skill in niceToHaveSkills

                     join applicantSkill in RelevantSkills(skillcategory.Programming) on skill​​.SkillName equals applicantSkill.SkillName
                     select skill).Count();

        }



        private int MetaSkillBonus()

        {

            List<skill> metaSkills = new List<skill>()

{

new skill () {SkillName = "Trives in a young and dynamic environment", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Curious and Learning", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Enjoy working closely with other developers and claimants", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Want to work in a small .NET team with senior and junior developers", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Has humor and lots of good mood", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Preferring delicious food from a canteen to boring food packages", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta},

new skill () {SkillName = "Looking forward to nice social events with colleagues", SkillLevel = SkillLevel.Average, SkillCategory = skillcategory.meta}

};

            return (from skill in metaSkills

                    join applicantSkill in this.RelevantSkills(skillcategory.meta) on skill.SkillName equals applicantSkill.SkillName

                    select skill).Count();

        }



        private List<skill> RelevantSkills(skillcategory skillCategory)

        {

            return (from skill in this.Skills

                    where skill.SkillCategory == skillCategory

                    select skill).ToList();

        }

    }



    public class applicant

    {

        public string name { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

    }



    public class skill

    {

        public string SkillName { get; set; }

        public skillcategory SkillCategory { get; set; }

        public SkillLevel SkillLevel { get; set; }

    }



    public enum SkillLevel

    {

        Beginner,

        Average,

        Pro

    }



    public enum skillcategory

    {

        Programming,

        meta

    }

}
