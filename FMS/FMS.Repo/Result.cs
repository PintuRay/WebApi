namespace FMS.Repo
{
    public class Result<T>
    {
        public T SingleObjData { get; set; }
        public List<T> CollectionObjData { get; set; } = [];
        public bool IsSucess { get; set; } = false;
        //public Exception Exception { get; set; }
    }
}
