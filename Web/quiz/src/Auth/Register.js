import { Button, Form, Input, Alert } from 'antd';
import { useState } from 'react';
import { Link, useNavigate } from "react-router-dom";
import axios from 'axios';
import { setUserSession } from '../Util/Common';

const Register = () => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const onFinish = (values) => {
    setLoading(true);
    setError(null);
    axios.post('https://localhost:44394/api/auth/register',
    {
      name: values.name,
      email: values.email,
      password: values.password,
      confirmPassword: values.confirmPassword
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
      <h3>Register</h3>

      {error && <Alert message={error} type="error" className='mb-2' />}

      <Form.Item
        label="Name"
        name="name"
        rules={[
          {
            required: true,
            message: 'Name is required!',
          },
          {
            min: 3,
            message: 'Name should be minimum 3 characters long',
          },
          {
            max: 50,
            message: 'Name should be maximum 50 characters long',
          }
        ]}
      >
        <Input />
      </Form.Item>

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
          },
          {
            min: 8,
            message: 'Password should contain minimum 8 characters',
          },
          {
            max: 32,
            message: 'Password should contain maximum 32 characters',
          }
        ]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item
        label="Confirm Password"
        name="confirmPassword"
        dependencies={['password']}
        rules={[
          {
            required: true,
            message: 'Confirm Password is required!',
          },
          ({ getFieldValue }) => ({
            validator(_, value) {
              if (!value || getFieldValue('password') === value) {
                return Promise.resolve();
              }
              return Promise.reject(new Error('Passwords do not match!'));
            },
          }),
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
          Register
        </Button>
      </Form.Item>

      <div className='text-center'>
        <Link to="/login">Already have an account? Login</Link>
      </div>
    </Form>
  )
};

export default Register;