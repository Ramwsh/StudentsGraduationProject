using StudentsGraduationProject.Model.Context;
using StudentsGraduationProject.Model.Entities;

namespace StudentsGraduationProject.Model.CRUD;

internal class Repository<T> : IRepository<T> where T : DomainEntity
{
    private readonly ApplicationContext<T> context;

    public Repository(ApplicationContext<T> context) => this.context = context;

    public void CloseConnection() => context.CloseConnection();    

    public void Create(T model)
    {
        context.Items.Add(model);
        context.SaveChanges();
    }

    public void Delete(T model)
    {
        context.Items.Remove(model);
        context.SaveChanges();
    }

    public IEnumerable<T> Read()
    {
        Console.WriteLine("Readed");
        return context.Items;
    }    

    public void Update(int Id, T model)
    {
        var targetModel = context.Items.Find(Id);
        if (targetModel != null)
        {
            context.Items.Remove(targetModel);
            context.Items.Add(model);
            context.SaveChanges();
        }
    }
}
