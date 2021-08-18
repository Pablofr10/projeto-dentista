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
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
