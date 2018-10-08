using System.Windows.Controls;

namespace ALSIE_ProjectModule.Abilities
{
    public class UserControlAbilityInjector
    {
        private UserControlAbility ability;
        private UserControl userControl;

        public UserControlAbilityInjector(UserControl userControl, UserControlAbility ability)
        {
            this.ability = ability;
            this.userControl = userControl;
        }

        public void InjectAbility()
        {
            this.ability.InjectAbility(this.userControl);
        }
    }
}
