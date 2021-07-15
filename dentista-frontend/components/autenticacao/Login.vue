<template>
  <v-card
    :loading="loading"
    class="mx-auto my-12"
    max-width="374"
    elevation="5"
  >
    <template slot="progress">
      <v-progress-linear color="deep-purple" height="10" indeterminate />
    </template>

    <v-card-title class="text-h4 text--primary">
      Login
    </v-card-title>

    <v-card-text>
      <v-text-field label="Usuário" />
      <v-text-field label="Senha" />
      <v-btn block color="success">
        Entrar
      </v-btn>
      <v-btn text class="mt-4" color="primary">
        Esqueceu a senha?
      </v-btn>
    </v-card-text>
    <v-card-actions>
      <v-btn text color="teal accent-4" @click="reveal = true">
        cadastrar
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {}
</script>
