namespace MagicBox.MF.Domain
{
    public abstract class Relationship : Model
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
