namespace Neadm.Models
{
    public class PapelUsuario
    {
        public int UsuarioId { get; set; }
        public int PapelId { get; set; }
        //Se não for nulo o role é em nível de disciplina
        public int DisciplinaId { get; set; }
        
        //Se não for nulo o role é em nível de curso
        public int CursoId { get; set; }
    }
}