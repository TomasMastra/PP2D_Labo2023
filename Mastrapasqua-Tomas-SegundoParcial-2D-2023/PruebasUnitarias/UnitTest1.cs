using Clases;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Comprar_Carro()
        {
            //Arrange
            Tienda.CargarTienda();
            List<Cliente> cliente = Tienda.ObtenerClientes();
            
            List <ListaCompras> carro = new List<ListaCompras>();
            carro.Add(new(12, 2, 5001, 2));
            carro.Add(new(13, 2, 5002, 4));
            carro.Add(new(14, 2, 5006, 1));

            cliente[0].ListaCompras = carro;

            //Act 
           string compra = Tienda.Comprar(cliente[0]);

            //Assert
            Assert.AreEqual(0, compra.Length);




        }


        [TestMethod]
        public void Test_Obtener_ListaFacturas()
        {
            //Arrange
            List<Factura> facturas = new List<Factura>();

            //Act
            facturas = Archivos<List<Factura>>.CargarDesdeArchivoXml("Facturas.Xml");

            //Assert
            Assert.IsNotNull(facturas);



        }

        [TestMethod]
        public void Test_Cargar_Cortes_Carne()
        {
            //Arrange
            List<Carniceria> cortesCarne = new List<Carniceria>();

            //Act
            cortesCarne = CarniceriaDAO.ObtenerListaCarne();


            //Assert
            Assert.AreNotEqual(0, cortesCarne.Count); 




        }
    }
}