using System;

namespace MyApp 
{
    internal class Program
    {  
        //delegate esempio:  si utilizza così.(Ricordarsi che il delegate ha lo stesso tipo e gli stessi paramenti del metodo a cui punta.
        static void Main(string[] args)
        {
            var a = new ClasseA();//Istanzio la mia classe

            MyDel delegato = new MyDel(a.Saluta); //instanzio il mio delegate

            Console.WriteLine(delegato("ciao"));//stampo il mio delegate

            //Concatenazione dei metodi con il delegate
            MyDel allMethods = a.Saluta;
            allMethods += a.Nominare; // con il += posso vedere entrambi i metodi in console, altrimenti bisogna mettere solo =
            Console.WriteLine(allMethods("michela"));

            //Registriamo il metodo nominare al nostro evento
            a.EventoStr += a.Nominare;
            a.MetodoEvento();

            //Altri modi per dichiarare un delegate con le expression lambda e stateman lambda (funzionini anonime)
            //delegato = (int a, int b) => a - b;    (expression lambda)

            /*delegato = (int a, int b) =>           (stateman lambda)
            {
                if (a > b)
                {
                    return a - b;

                }
                return a + b;

            };
            */

            //delegato = delegate (int a,int b)      (altro modo per dichiarare un delegate con un metodo)
            //{ 
            //    return a + b;       
            
            //}
        }   
        
        
    }

     public delegate string MyDel(string str);// i delegate si possono dichiarere fuori dalla classe (quando si dichiarano all'interno si dicono 'delegate innestati')

    public class ClasseA
    {
        //Ora creiamo un'evento
        public event MyDel EventoStr;

        //creazione primo metodo
        public string Saluta(string saluto)
        {

            return saluto;

        }

        //Creiamo un nuovo metodo
        public string Nominare(string nome) 
        { 
            return nome;    
        
        }
        
        //Creazione del metodo per invocare l'evento
        public void MetodoEvento()
        {

            
            EventoStr.Invoke("Hola");

        }
    }
}
