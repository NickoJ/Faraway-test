namespace NickoJ.DinoRunner.Engine
{
    public interface IServiceLocator
    {
        public T Get<T>();
   }
}