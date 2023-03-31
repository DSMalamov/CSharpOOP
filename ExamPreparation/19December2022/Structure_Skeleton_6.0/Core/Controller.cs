using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;
        private string[] allowedCategories = new string[] { "TechnicalSubject", "EconomicalSubject", "HumanitySubject" };

        public Controller()
        {
            subjects= new SubjectRepository();
            students= new StudentRepository();
            universities= new UniversityRepository();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            if (!allowedCategories.Contains(subjectType))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            Subject subject = null;

            if (subjectType == typeof(TechnicalSubject).Name)
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            else if (subjectType == typeof(EconomicalSubject).Name)
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            else if (subjectType == typeof(HumanitySubject).Name)
            {
                subject = new HumanitySubject(0, subjectName);
            }

            subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsAsInt = requiredSubjects.Select(x => subjects.FindByName(x).Id).ToList();

            University uni = new University(0, universityName, category, capacity, requiredSubjectsAsInt);

            universities.AddModel(uni);

            return string.Format(OutputMessages.UniversityAddedSuccessfully,universityName,universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            Student student = new Student(0,firstName,lastName);

            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully,firstName,lastName,students.GetType().Name);
        }
        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);

            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            ISubject subject= subjects.FindById(subjectId);

            if (subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);

            string[] studentNames = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, studentNames[0], studentNames[1]);
            }

            IUniversity university = universities.FindByName(universityName);

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var subject in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(subject))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, university.Name);
                }
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }


        public string UniversityReport(int universityId)
        {
            IUniversity uni = universities.FindById(universityId);
            StringBuilder sb = new StringBuilder();
            int count = AdmittedStudentsCount(uni);
            sb.AppendLine($"*** {uni.Name} ***");
            sb.AppendLine($"Profile: {uni.Category}");
            sb.AppendLine($"Students admitted: {count}");
            sb.AppendLine($"University vacancy: {uni.Capacity - count}");

            return sb.ToString().Trim();

        }

        private int AdmittedStudentsCount(IUniversity university)
        {
            int count = 0;
            foreach (var student in students.Models)
            {
                if (student.University?.Id == university.Id)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
