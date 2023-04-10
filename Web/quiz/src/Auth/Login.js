import { Button, Form, Input } from 'antd';
import { useState } from 'react';

const Login = () => {
  const [loading, setLoading] = useState(false);

  const onFinish = (values) => {
    setLoading(true);
  };

  return (
    <Form
      name="login"
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
    </Form>
  )
};

export default Login;