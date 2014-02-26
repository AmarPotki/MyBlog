namespace MyBlog.MVC.Web.BootstrapperTasks
{
    public interface IBootstrapTask
    {
        void Execute();
        int Priority { get; }
    }
}
