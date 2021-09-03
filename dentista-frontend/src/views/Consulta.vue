<template>
  <div>
    <h1 class="font-sans text-3xl text-center py-2">
      Consultas
    </h1>
    <div v-if="rotaAtual === 'Consultas'">
      <FiltrosConsulta class="mb-5" />
      <TabelaConsulta />
    </div>
    <div v-if="rotaAtual === 'Adicionar'">
      <Adicionar />
    </div>
  </div>
</template>

<script>
import TabelaConsulta from "../components/TabelaConsulta.vue";
import FiltrosConsulta from "../components/FiltrosConsulta.vue";
import Adicionar from "../components/consultas/Adicionar.vue";
import { useRoute } from "vue-router";
import { computed } from "@vue/reactivity";
export default {
  components: {
    TabelaConsulta,
    FiltrosConsulta,
    Adicionar
  },
  setup() {
    const rotaAtual = computed(() => {
      const { name } = useRoute();
      return name;
    });

    return {
      rotaAtual
    };
  }
};
</script>

<style lang="scss" scoped></style>
