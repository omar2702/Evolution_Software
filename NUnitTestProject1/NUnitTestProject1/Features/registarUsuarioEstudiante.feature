Feature: registarUsuarioEstudiante

A short summary of the feature

@tag1
Scenario: El usuario estudiante quiere registrarse en Interlab para aplicar a una oferta de trabajo
	Given como usuario ingreso point para registrarme
	When como usuario me registro con mis datos
	| username  | password  | email          | datecreated         |
	| username1 | password1 | email1gmailcom | 2020-08-08T13:23:44 |
	Then registro mis datos de manera exitosa
