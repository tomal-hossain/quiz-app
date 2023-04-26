import { Button } from 'antd';
import { removeUserSession } from '../Util/Common';
import { useNavigate } from "react-router-dom";

const Logout = () => {
  const navigate = useNavigate();

  const onClick = () => {
    removeUserSession();
    navigate('/login');
  }

  return (
    <Button type="primary" htmlType="submit" onClick={onClick}>
      Logout
    </Button>
  )
};

export default Logout;