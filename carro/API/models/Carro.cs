namespace API.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Criado { get; set; }

        public Carro()
        {
            this.Criado = DateTime.Now;
        }
    }
}
