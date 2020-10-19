Feature: registrarUsuarioEmpresa

A short summary of the feature

@tag1
Scenario: El usuario se encuentra en la pantalla de registro de la pagina web
	Given como usuario ingreso a la pagina web
	When como usuario me registro con los datos 
	| name     | description      | sector | email           | phone  | address             | country | city |
    | Interlab | Empresa dedicada | 2      | interlabmailcom | 665579 | Monterrico cuadra23 | Peru    | Lima |
	Then se registra mis datos con exito
    