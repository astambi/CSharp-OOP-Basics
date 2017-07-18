namespace BashSoft
{
    public class Startup
    {
        public static void Main()
        {
            var tester = new Tester();
            var ioManager = new IOManager();
            var repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            var currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            var reader = new InputReader(currentInterpreter);
            reader.StartReadingCommands();
        }
    }
}
