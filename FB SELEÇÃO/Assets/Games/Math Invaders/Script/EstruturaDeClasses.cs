namespace EstruturaDeClasses
{
    public enum categoria
    {
        arqueiro, padre
    }
    
    class Guerreiro
    {
        public Guerreiro (string nome, categoria categoria, string especial, int forca)
        {
            this.nome=nome;
            this.categoria=categoria;
            this.especial=especial;
            this.forca=forca;
        }
        string nome;
        categoria categoria;
        string especial;
        int forca;

        public int ataque(){
            if (categoria==categoria.arqueiro)
            {
                forca*=2;
            }else if (categoria==categoria.padre)
            {
                forca*=3;
            }else
            {
                forca/=2;
            }
            return forca;
        }
    }

    class Monstro
    {
        public Monstro(string nome, int forca)
        {
            this.nome=nome;
            this.forca=forca;
        }
        string nome;
        int forca;
        public int defesa()
        {
            return forca*2;
        }
    }
}