namespace Abacus.Core
{
    public interface ITemplate
    {
        string Name { get; }
        string Version { get; }
        bool IsArchived { get; }
        ITransition Root { get; set; }
        //IList<ITransition> Transitions { get; set; }
    }
}