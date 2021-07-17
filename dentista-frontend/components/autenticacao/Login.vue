<template>
  <div>
    <v-card-title class="text-h4 text--primary">
      Login
    </v-card-title>

    <v-card-text>
      <v-alert v-if="erroMensagem" dense text type="error">
        {{ mensagem }}
      </v-alert>
      <v-text-field v-model="email" label="Usuário" />
      <v-text-field v-model="password" label="Senha" />
      <v-btn block color="success" @click="login()">
        Entrar
      </v-btn>
      <v-btn text class="mt-4" color="primary">
        Esqueceu a senha?
      </v-btn>
    </v-card-text>
  </div>
</template>
<script>
export default {
  data () {
    return {
      email: '',
      password: '',
      senhaConfirmada: '',
      mensagem: '',
      erroMensagem: false
    }
  },
  methods: {
    async login () {
      try {
        await this.$axios
          .$post('/Autenticacao/login', {
            email: this.email,
            password: this.password
          })
          .then((res) => {
            window.localStorage.setItem('token', res.token)
          })
      } catch (error) {
        const { Mensagem } = error.response.data
        this.mensagem = Mensagem
        this.erroMensagem = true
      }
    }
  }
}
</script>
