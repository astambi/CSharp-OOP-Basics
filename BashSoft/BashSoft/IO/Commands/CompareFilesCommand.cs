using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 3)
            {
                string firstPath = this.Data[1];
                string secondPath = this.Data[2];

                this.Judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
