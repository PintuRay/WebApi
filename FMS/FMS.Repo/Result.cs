namespace FMS.Repo
{
    public class Result<T>
    {
        public T SingleObjData { get; set; }
        public List<T> CollectionObjData { get; set; } = [];
        public int Count = 0;
        public bool IsSucess { get; set; } = false;
    }
}
