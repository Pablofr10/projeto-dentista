import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";

function lazyLoad(view) {
  return () => import(`../views/${view}.vue`);
}

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/paciente",
    name: "Paciente",
    component: lazyLoad("Paciente")
  },
  {
    path: "/consultas",
    name: "Consultas",
    component: lazyLoad("Consulta")
  },
  {
    path: "/consultas/adicionar",
    name: "Adicionar",
    component: lazyLoad("Consulta")
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
