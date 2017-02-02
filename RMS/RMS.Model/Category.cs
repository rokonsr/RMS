using System;

namespace RMS.Model
{
    public class Category : CommonModel
    {
        public short CategoryId { get; set; }
        public string CategoryName { get; set; }
        public byte CategoryLevel { get; set; }
        public string CategoryDescription { get; set; }
        public short? CategoryParentId { get; set; }

        public short SecondCategoryId { get; set; }
        public string SecondCategoryName { get; set; }
        public short ThirdCategoryId { get; set; }
        public string ThirdCategoryName { get; set; }
    }
}
