import { Button, Form, Input, Alert } from 'antd';
import { useState } from 'react';
import axios from 'axios';
import { setUserSession } from '../Util/Common';
import { Link, useNavigate } from "react-router-dom";

const Login = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const onFinish = (values) => {
    setLoading(true);
    setError(null);
    axios.post('https://localhost:44394/api/auth/login',
    {
      email: values.email,
      password: values.password
    })
    .then(response => {
      setLoading(false);
      setUserSession(response.data.token, response.data.user);
      navigate("/");
    })
    .catch(error => {
      setLoading(false);
      if (error.response && error.response.status === 400)
        setError(error.response.data.message);
      else
        setError("Something went wrong. Please try again later.");
    });
  };

  return (
    <Form
      name="login"
      className='text-center'
      labelCol={{
        span: 8,
      }}
      wrapperCol={{
        span: 16,
      }}
      style={{
        maxWidth: 600,
        border: '1px solid grey',
        padding: '20px',
        margin: 'auto',
        marginTop: '50px'
      }}
      onFinish={onFinish}
      autoComplete="off"
    >
      <h3>Login</h3>

      {error && <Alert message={error} type="error" className='mb-2' />}

      <Form.Item
        label="Email"
        name="email"
        rules={[
          {
            required: true,
            message: 'Email is required!',
          },
          {
            type: 'email',
            message: 'Invalid email!',
          }
        ]}
      >
        <Input />
      </Form.Item>

      <Form.Item
        label="Password"
        name="password"
        rules={[
          {
            required: true,
            message: 'Password is required!',
          }
        ]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item
        wrapperCol={{
          offset: 8,
          span: 16,
        }}
      >
        <Button type="primary" htmlType="submit" disabled={loading}>
          Login
        </Button>
      </Form.Item>

      <Link to="/register">Don't have an account? Register now!</Link>
    </Form>
  )
};

export default Login;