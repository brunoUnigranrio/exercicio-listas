 using System;

 class Lista{

    	private int indiceVisivelAoUser, tamanhoReal;
    	private int[] lista;
		bool ordenado = false;

    	//constructor
    	public Lista(int tamanho){
        	this.indiceVisivelAoUser = tamanho-1;
        	this.tamanhoReal = tamanho + 10;
        	this.lista = new int[tamanhoReal];
    	}

    	//preenchendo aleatóriamente
    	public void PreencherAleatoriamente(){
        	Random aleatorio = new Random();
			int i = 0;
        	for(i=0; i < indiceVisivelAoUser+1; i++){
            	int valor = aleatorio.Next(0,100);
				this.lista[i] = valor;
        	}
			Console.WriteLine("TAMANHO PRA O USER " + indiceVisivelAoUser);
			Console.WriteLine("Este é o valor de i no fim do loop "+ i);
			itemsNoArray();
    	}

    	//preenchendo ordenadamente
    	public void PreencherOrdenadamente(){
        	Console.WriteLine("Digite os "+ indiceVisivelAoUser + " items da lista");
        	for(int i = 0; i < indiceVisivelAoUser; i++){
            	Console.Write("Digite o valor que ficará armazenado no índice " + i+ ": ");
            	this.lista[i] = Int32.Parse(Console.ReadLine());
        	}
    	}

    	public bool InserirItem(int item) {
			Console.WriteLine("Tamanho para user: "+ indiceVisivelAoUser);
        	if (tamanhoReal > indiceVisivelAoUser) {
            	indiceVisivelAoUser++;
            	lista[indiceVisivelAoUser] = item;
				Console.WriteLine("Tamanho para user: "+ indiceVisivelAoUser);
				Console.WriteLine("LISTANDO APÓS INSERIR");
				itemsNoArray();
            	return true;
        	}

        	return false;
    	}

		private void itemsNoArray() {
			for(int i = 0; i < lista.Length; i++) {
					Console.Write(lista[i] + ",");
				}
		}

    	public bool RemoverPorIndice(int indice) {
        	if (indice > indiceVisivelAoUser) {
            	return false;
        	}
        	lista[indice] = lista[indiceVisivelAoUser];
        	indiceVisivelAoUser--;
        	return true;

    	}



    	public bool RemoverPorValor(int valor) {
        	int indiceDoValorEncontrado = this.BuscaValor(valor);
        	if (indiceDoValorEncontrado < 0) {
            	return false;
        	}
        	lista[indiceDoValorEncontrado] = lista[indiceVisivelAoUser];
        	indiceVisivelAoUser--;
        	return true;

    	}
    	//buscando valor e retorna o índice
    	/**
    	* Retorna o índice do valor passado como argumento, ou -1 caso não seja encontrado
    	**/
    	public int BuscaValor(int valor){
        	int returnedValue = -1;
        	for(int i = 0; i < indiceVisivelAoUser+1; i++){
            	if(lista[i] == valor){
                	returnedValue = i;
                	break;
            	}
        	}
        	return returnedValue;
    	}

    	//retorna o valor no índice provido ou -1 caso o índice não exista
    	public int RetornaValorIndice(int indice){
        	return indiceVisivelAoUser >= indice ? lista[indice] : -1;
    	}

    	public void LimparLista() {
        	indiceVisivelAoUser = 0;
    	}

    	public int Length(){
        	return indiceVisivelAoUser + 1;

    	}
    	 
         public void Ordernar(){
   		 do{
   		 int auxiliar;
   		 for(int i = 0; i < indiceVisivelAoUser; i++){
   			 if(lista[i] > lista[i+1]){
   				 auxiliar = lista[i];
   				 lista[i] = lista[i+1];
   				 lista[i+1] = auxiliar;
   			 }
   		 }
   		 }while(ordenado);
		 ordenado = true;		
   	 }
	}