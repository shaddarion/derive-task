using ApplicationFramework.Components;

namespace ApplicationFramework.WorkFlows
{
    public class AddItemWorkFlow
    {
        public void AddItemByName(string itemName)
        {
            new HeaderComponent()
                .Input_SearchField_Value(itemName)
                .Click_Search_Button();
        }
    }
}
