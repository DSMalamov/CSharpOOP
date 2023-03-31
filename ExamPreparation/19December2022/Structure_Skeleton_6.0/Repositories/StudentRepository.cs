using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories;

public class StudentRepository : IRepository<IStudent>
{
    private List<IStudent> models;

    public StudentRepository()
    {
        models = new List<IStudent>();
    }
    public IReadOnlyCollection<IStudent> Models
    {
        get { return models.AsReadOnly(); }
    }

    public void AddModel(IStudent model)
    {
        Student student = new Student(models.Count + 1, model.FirstName, model.LastName);

        models.Add(student);
    }

    public IStudent FindById(int id)
        => models.FirstOrDefault(x => x.Id == id);

    public IStudent FindByName(string name)
    {
        string[] fullname = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string firstName = fullname[0];
        string lastName = fullname[1];

        return models.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName);
    }
}
