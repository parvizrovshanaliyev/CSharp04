using LMSWithArrayList.Enums;

namespace LMSWithArrayList.Extensions
{
    public static class MenuOptionExtensions
    {
        public static string GetDisplayText(this MenuOption option)
        {
            return option switch
            {
                MenuOption.AddBook => "Add Book",
                MenuOption.AddMagazine => "Add Magazine",
                MenuOption.ListAllItems => "List All Items",
                MenuOption.SearchItems => "Search Items",
                MenuOption.BorrowItem => "Borrow Item",
                MenuOption.ReturnItem => "Return Item",
                MenuOption.DeleteItem => "Delete Item",
                MenuOption.ViewItemHistory => "View Item History",
                MenuOption.Exit => "Exit",
                _ => option.ToString()
            };
        }

        public static int ToInt(this MenuOption option)
        {
            return (int)option;
        }
    }
}