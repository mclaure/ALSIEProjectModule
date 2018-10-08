namespace ALSIE_ProjectModule.Controls.Toolbox
{
    public interface ToolBoxItemDelegate
    {
        void NotifySelectAction(ToolBoxItem toolBoxItem);
        void NotifyUnselectAction();
    }
}
