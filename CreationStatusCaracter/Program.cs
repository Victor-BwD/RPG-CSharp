using CreationStatusCaracter;

Creation creation = new Creation();
FirstEncouter encouter1 = new FirstEncouter();

creation.CreationCaracter();

string name = creation.status.Name;
string className = creation.status.Class;
int age = creation.status.Age;
int strength = creation.status.Strength;
int dexterity = creation.status.Dex;
int intelligence = creation.status.Intelligence;
int charisma = creation.status.Charisma;

encouter1.FirstContact(name, age);
