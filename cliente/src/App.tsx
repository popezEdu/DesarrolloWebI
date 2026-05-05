import './App.css'
import { Layout } from './layout/Layout'
import { ListaProductos } from './components/Productos/ListaProductos'

function App() {
  return (
    <Layout>
      <div className="mb-4">
        <div className="d-flex flex-column flex-md-row justify-content-between align-items-start align-items-md-center gap-3">
          <div>
            <span className="badge bg-info text-dark mb-2">Endpoint</span>
            <h2 className="h4">Productos disponibles</h2>
            <p className="text-muted mb-0">
              Consulta datos desde el endpoint de productos.
            </p>
          </div>
        </div>
      </div>
      <ListaProductos />
    </Layout>
  )
}

export default App
