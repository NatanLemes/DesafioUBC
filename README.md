# DesafioUBC

Funcionamento API Students do desafio UBC.
Rodando a API pelo swagger:
  - Todas rotas estão bloqueadas, e necessitam de uma autorização para serem liberadas para funcionamento. 
 ![image](https://github.com/NatanLemes/DesafioUBC/assets/57756462/5703034e-a8d3-4fb1-baf3-00f5aa5f0a1e)
  - Essa autorização será gerada no momento onde o login é efetuado. As credenciais do usuário padrão é: admin/ admin
![image](https://github.com/NatanLemes/DesafioUBC/assets/57756462/259ac756-7ec6-4835-a7a0-b29e69096fb5)
(Exemplo do Token Gerado) ![image](https://github.com/NatanLemes/DesafioUBC/assets/57756462/8406ecd0-ddd5-431a-b2e9-199c17f34cf5)
  - É necessário selecionar o token erado, após isso ir no cadeado localizado no topo da página (Authorize) e no campo value, preencher: Bearer + {token}.

![image](https://github.com/NatanLemes/DesafioUBC/assets/57756462/757a68d9-8832-4c10-ad4a-45bab0217114)

Após liberar a autorização, o usuário podera utilizar todas as rotas de Students livremente. 

Obs.: A base de estudante já vem préviamente carregada.

