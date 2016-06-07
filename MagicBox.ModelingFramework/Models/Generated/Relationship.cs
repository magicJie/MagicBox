namespace MagicBox.MF.Models
{
    public abstract partial class Relationship : Model
    {
        public Model Related
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Model Source
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
