using CreationStatusCaracter;

Creation creation = new Creation();
FirstEncouter encouter1 = new FirstEncouter();

creation.CreationCaracter();

string name = creation.status.Name;
string className = creation.status.Class;
int age = creation.status.Age;

encouter1.FirstContact(name, age);
