namespace APBD_19._03_CW2.MyUtils
{
    public interface IDataReader<T,S>
    {
        public S ReadData(T path);
    }
}