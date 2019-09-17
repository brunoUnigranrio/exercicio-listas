using System;

class Lista
{

    private int indiceVisivelAoUser, tamanhoReal;
    private int[] lista;
    public bool ordenado = false;
    
    //constructor
    public Lista(int tamanho)
    {
        this.indiceVisivelAoUser = tamanho -1;
        this.tamanhoReal = tamanho + 10;
        this.lista = new int[tamanhoReal];
    }

    //preenchendo aleatóriamente
    public void PreencherAleatoriamente()
    {
        Random aleatorio = new Random();
        int i = 0;
        for (i = 0; i < indiceVisivelAoUser + 1; i++)
        {
            int valor = aleatorio.Next(0, 100);
            this.lista[i] = valor;
        }
        Console.WriteLine("TAMANHO PRA O USER " + indiceVisivelAoUser);
        Console.WriteLine("Este é o valor de i no fim do loop " + i);
        itemsNoArray();
    }

    //preenchendo ordenadamente
    public void PreencherOrdenadamente()
    {
        Console.WriteLine("Digite os " + indiceVisivelAoUser + " items da lista");
        for (int i = 0; i < indiceVisivelAoUser; i++)
        {
            Console.Write("Digite o valor que ficará armazenado no índice " + i + ": ");
            this.lista[i] = Int32.Parse(Console.ReadLine());
        }
		ordenado = false;
    }

    public bool InserirItem(int item)
    {
        Console.WriteLine("Tamanho para user: " + indiceVisivelAoUser);
        if (tamanhoReal > indiceVisivelAoUser)
        {
            indiceVisivelAoUser++;
            lista[indiceVisivelAoUser] = item;
            Console.WriteLine("Tamanho para user: " + indiceVisivelAoUser);
            Console.WriteLine("LISTANDO APÓS INSERIR");
            itemsNoArray();       
			ordenado = false;
            return true;
        }
		
        return false;
    }

    private void itemsNoArray(bool mostrarTudo = false)
    {
		if (mostrarTudo){
			for (int i = 0; i < lista.Length; i++)
        {
            Console.Write(lista[i] + ",");
        }
		} else {
			for (int i = 0; i < indiceVisivelAoUser; i++)
        {
            Console.Write(lista[i] + ",");
        }
		}
		Console.WriteLine("");
    }

    public bool RemoverPorIndice(int indice)
    {
        if (indice > indiceVisivelAoUser)
        {
            return false;
        }
        lista[indice] = lista[indiceVisivelAoUser];
        indiceVisivelAoUser--;
		ordenado = false;
        return true;

    }



    public bool RemoverPorValor(int valor)
    {
        int indiceDoValorEncontrado = this.BuscaValor(valor);
        if (indiceDoValorEncontrado < 0)
        {
            return false;
        }
        lista[indiceDoValorEncontrado] = lista[indiceVisivelAoUser];
        indiceVisivelAoUser--;
		ordenado = false;
        return true;

    }

    public int BuscaBinaria(int elemento){
        int maximo = indiceVisivelAoUser;
        int minimo = 0;
        int media;
        int indexElemento = -1;

        while((minimo <= maximo) && (indexElemento == -1)){
            media = (minimo+maximo)/2;
            if(lista[media] == elemento){
                indexElemento = media;
            }else if(lista[media] < elemento){
                minimo=media++;
            }else{
                maximo=media--;
            }
        }
        return indexElemento;
    }

    //buscando valor e retorna o índice
    /**
    * Retorna o índice do valor passado como argumento, ou -1 caso não seja encontrado
    **/
    public int BuscaValor(int valor)
    {
        int returnedValue = -1;
        for (int i = 0; i < indiceVisivelAoUser + 1; i++)
        {
            if (lista[i] == valor)
            {
                returnedValue = i;
                break;
            }
        }
        return returnedValue;
    }

    //retorna o valor no índice provido ou -1 caso o índice não exista
    public int RetornaValorIndice(int indice)
    {
        return indiceVisivelAoUser >= indice ? lista[indice] : -1;
    }

    public void LimparLista()
    {
        indiceVisivelAoUser = 0;
		ordenado = false;
    }

    public int Length()
    {
        return indiceVisivelAoUser + 1;

    }

    public void Ordernar()
    {
		if (ordenado) {
			Console.WriteLine("Não é necessário, lista já está ordenada");
			itemsNoArray();
			return;
		}
		bool rodando = false;
		Console.WriteLine("Antes da ordenação");
		itemsNoArray();
		int indiceUltimoElementoNaoOrdenado = indiceVisivelAoUser;
		Console.WriteLine("Deve rodar até: "+indiceUltimoElementoNaoOrdenado);
        do
        {
			/*
			 * já que usamos o do while, esse código rodará ao menos uma vez,
			 * durante o loop for que checa cada um dos ítens não organizados	
			 * "rodando" será setado para true quando o ítem da esquerda for maior
			 * do que o da direita, efetivamente passando por todos os números
			 * toda vez que houver uma movimentação.
			 * Caso não haja movimentação até o fim do loop for, isso significa que
			 * não há mais números maiores à esquerda, rodando se manterá
			 * false, finalizando o loop while e encerrando o algoritmo.
			 */ 
			rodando = false;
            int auxiliar;
            for (int i = 0; i < indiceUltimoElementoNaoOrdenado; i++)
            {
                if (lista[i] > lista[i + 1])
                {
					Console.WriteLine("Item na posição "+ i +" é maior que o seu sucessor " +(i +1));
					Console.WriteLine(lista[i] + " > " + lista[i+1]);
                    auxiliar = lista[i];
                    lista[i] = lista[i + 1];
                    lista[i + 1] = auxiliar;
					rodando = true;
                }
            }
			indiceUltimoElementoNaoOrdenado --;
        } while (rodando);
		ordenado = true;
		Console.WriteLine("Depois da ordenação:");
		itemsNoArray();

    }
}