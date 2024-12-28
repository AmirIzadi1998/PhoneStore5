namespace PhoneStore5.Utility
{
    public class GetQueryDapper
    {
        public string QueryInsert()
        {
            return
                "INSERT Products (Name, NameChipset, Camera, Description, InsertTime) VALUES (@Name, @NameChipset, @Camera, @Description, @InsertTime)";
        }

        public string QueryGetAll()
        {
            return
                "Select Id, Name, NameChipset, Camera, Description, InsertTime From Products ";
        }
        public string QueryUpdate()
        {
            return
                "Update Products Set Name=@Name, NameChipset=@NameChipset, Camera=@Camera, Description=@Description, InsertTime=@InsertTime Where Id=@Id";
        }
        public string GetById()
        {
            return
                "Select  Id, Name, NameChipset, Camera, Description, InsertTime From Products where Id=@Id ";
        }
        public string Delete()
        {
            return
                "Delete Products where Id=@Id ";
        }
        public string QuerySearch()
        {
            return
                "Select  Id, Name, NameChipset, Camera, Description, InsertTime From Products where Id=@Id ";
        }

    }
}