import { UnorderedListOutlined, AppstoreAddOutlined, SwapOutlined, HomeOutlined, LogoutOutlined } from '@ant-design/icons';
import { Layout, Menu, theme } from 'antd';
import { createElement, useEffect, useState } from "react";
import { Outlet, Link } from 'react-router-dom'
import { getUser } from './Util/Common'

const { Content, Footer, Sider } = Layout;

const items = [
  {
    key: 0,
    label: (
      <Link to='/' style={{ textDecoration: "none" }}>Home</Link>
    ),
    icon: HomeOutlined,
  },
  {
    key: 1,
    label: (
      <Link to='/quiz-list' style={{ textDecoration: "none" }}>Quiz</Link>
    ),
    icon: UnorderedListOutlined
  },
  {
    key: 4,
    label: (
      <Link to='/logout' style={{ textDecoration: "none" }}>Logout</Link>
    ),
    icon: LogoutOutlined
  }
]

const createQuizItem = 
  {
    key: 2,
    label: (
      <Link to='/create-quiz' style={{ textDecoration: "none" }}>Create Quiz</Link>
    ),
    icon: AppstoreAddOutlined
  };
const requestItem = {
    key: 3,
    label: (
      <Link to='/requests' style={{ textDecoration: "none" }}>Approval Requests</Link>
    ),
    icon: SwapOutlined
  };

const AppLayout = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();

  const [user, setUser] = useState(null);
  const [navItems, setNavItems] = useState(items);

  useEffect(() => {
    setUser(getUser());
  }, []);

  useEffect(() => {
    if(user && user.isAdmin) {
      let updatedNavItems = [...items];
      updatedNavItems.splice(1, 0, createQuizItem, requestItem)
      setNavItems(updatedNavItems);
    }
  }, [user]);

  return (
    <Layout>
      <Sider
        breakpoint="lg"
        collapsedWidth="0"
      >
        <Menu
          theme="dark"
          mode="inline"
          items={navItems.map(
            item => ({
              key: item.key,
              icon: createElement(item.icon),
              label: item.label
            })
          )}
        />
      </Sider>
      <Layout>
        <Content style={{ margin: '24px 16px 0' }}>
          <div style={{ padding: 24, minHeight: '85vh', background: colorBgContainer }}>
            <Outlet />
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>Quiz app ©2023</Footer>
      </Layout>
    </Layout>
  );
};

export default AppLayout;