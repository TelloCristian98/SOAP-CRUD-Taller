from zeep import Client
from zeep.transports import Transport
from requests import Session

# Configuración del servicio SOAP
BASE_URL = "http://localhost:5278/soap"

# Configurar transporte para ignorar WSDL (si el archivo WSDL no está disponible)
session = Session()
session.verify = False
transport = Transport(session=session)

# Crear cliente directo para categorías y productos
category_client = Client(f"{BASE_URL}/Category.asmx?wsdl", transport=transport)
product_client = Client(f"{BASE_URL}/Product.asmx?wsdl", transport=transport)

# Consultar todos los productos
def get_all_products():
    try:
        response = product_client.service.GetAllProducts()
        print("Productos obtenidos:")
        for product in response:
            print(f"ID: {product.productid}, Nombre: {product.productname}, Precio: {product.unitprice}, Categoría ID: {product.categoryid}")
    except Exception as e:
        print(f"Error al obtener productos: {e}")

# Consultar todas las categorías
def get_all_categories():
    try:
        response = category_client.service.GetAllCategories()
        print("Categorías obtenidas:")
        for category in response:
            print(f"ID: {category.categoryid}, Nombre: {category.categoryname}, Descripción: {category.description}")
    except Exception as e:
        print(f"Error al obtener categorías: {e}")

if __name__ == "__main__":
    print("\n--- Categorías ---")
    get_all_categories()
    print("\n--- Productos ---")
    get_all_products()