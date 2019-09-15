/*
OBS: em uma lista não ordenada, a remoção de um item se faz através da inserção do último elemento no índice que está sendo “removido” e em seguida tratando o “valor total” como reduzido uma vez (do índice excluído).
em um lista ordenada, a remoção se faz através da inserção dos itens da direita sobrescrevendo uma casa para a esquerda e em seguida tratando o “valor total” como reduzido uma vez (do índice excluído)
Incluir as ações de ORDENAR, BUSCA BINÁRIA. (obs: buscas binárias só podem ser realizadas em listas previamente ordenadas)
*/



using System;

enum STATE {
	START,
	MAINMENU,
	INSERTITEM,
	SEARCHBYID,
	SEARCHBYVALUE,

	REMOVEBYID,
	REMOVEBYVALUE,
    
}

namespace listas
{
	public class Program
	{
   	public static void Main(string[] args)
    	{
        	Lista l1 = new Lista(2);
        	bool rodando = true;
        	STATE currentState = STATE.START;

        	while(rodando) {
            	switch(currentState) {
                	case STATE.START:
                    	Console.Write("Qual o tamanho da lista?");
                    	int r = Int32.Parse(Console.ReadLine());
                    	l1 = new Lista(r);
                    	string[] opcoes = {"Gerar aleatoriamente", "Inserir valores um à um"};
                    	int re = MostrarPerguntas("Como gostaria de adicionar itens para esse array?", opcoes);
                    	if (re == 0) {
                        	l1.PreencherAleatoriamente();
                    	}
                    	else if (re == 1) {
                        	l1.PreencherOrdenadamente();
                    	}
                    	currentState = STATE.MAINMENU;
                    	break;
                	case STATE.MAINMENU:
                	string[] mainMenuOptions = {"Ver itens no array", "Inserir item", "Procurar item", "Acessar um valor por índice", "Limpar a lista e recomeçar", "Sair"};
                    	int rMainMenu = MostrarPerguntas("O que deseja fazer?", mainMenuOptions);
                    	if(rMainMenu == 0) {
                        	Console.WriteLine("O Array possui "+ l1.Length() + " items");
                        	Console.Write("Seus items são: " );
							Console.WriteLine("\n\n");
                        	for(int i = 0; i < l1.Length(); i++) {
                            	Console.Write(l1.RetornaValorIndice(i) +", ");
                        	}
                        	Console.WriteLine("");
   						 
                    	}else if(rMainMenu == 1){
   						 
   						 Console.WriteLine("Informe o valor desejado");
                   		 int valorInserido = Int32.Parse(Console.ReadLine());
   						 bool resultado = l1.InserirItem(valorInserido);
   						 if(resultado == true){
   							 Console.WriteLine("Valor Inserido com sucesso");
   						 }else {
   							 Console.WriteLine("Não deu.. Sem memória");
   						 }
   							 
   					 }
                     	else if(rMainMenu == 2) {
                        //  currentState = STATE.SEARCHBYID;
   						 Console.Write("Informe o valor à ser procurado");
                   		 int val = Int32.Parse(Console.ReadLine());
   						 int resultBuscaValor = l1.BuscaValor(val);
   						 if(resultBuscaValor < 0){
   							 Console.WriteLine("Valor não encontrado");
   						 }else {
   							 Console.WriteLine("Valor encontrado no índice " + resultBuscaValor);
   						 }
                    	}
   					 else if (rMainMenu == 3) {
                       	Console.Write("Informe o índice desejado");
                   		 int indice = Int32.Parse(Console.ReadLine());
   						 int valorIndice = l1.RetornaValorIndice(indice);
   						 if(valorIndice < 0){
   							 Console.WriteLine("O índice informado ultrapassa o limite da lista");
   						 }else {
   							 Console.WriteLine("Valor encontrado " + valorIndice);
   						 }
                    	}
   					 else if (rMainMenu == 4) {
                        	currentState = STATE.START;
                    	}
   					 else if (rMainMenu == 5) {
                        	rodando = false;
   						 break;
                    	}
                    	break;
   					 

            	}
        	}

    	}
    	static int MostrarPerguntas(string titulo, string[] opcoes) {
        	Console.WriteLine(titulo);
        	Console.WriteLine("---------------------------");
        	for(int i = 0; i < opcoes.Length; i++) {
            	Console.WriteLine(i +"- "+ opcoes[i]);
        	}
        	return Int32.Parse(Console.ReadLine());
    	}

	}
}
