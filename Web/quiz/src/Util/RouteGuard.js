import { Navigate } from 'react-router-dom';
import { getToken } from './Common';
 
function RouteGuard({ component: Component, ...rest }) {
  return (
    getToken()
      ? <Component { ...rest } />
      : <Navigate to={{ pathname: '/login' }} />
  )
}
 
export default RouteGuard;