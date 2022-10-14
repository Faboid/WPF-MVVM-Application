# WPF-MVVM-Application

A template for creating a .Net WPF Application using the MVVM architecture.

Provides base commands(sync & async), a base viewmodel and error view model(to be used in a composite fashion), and an index view & viewmodel that shows how to wire everything up.
An integrated notification system is used to send messages to the user, but, unlike MessageBox.Show(), the thread doesn't stop for an answer.

## Usage:
1. Clone the repo to your computer.
2. Using Visual Studio, load the project and go to Project -> Export Template.
3. Select Project template, then add the template options(name, description...).
4. Click 'finish'.

Whenever you need to create a new WPF assembly, you'll find the created project template in the "add new project" VS menu.
