<template>
  <div class="home">
    <h1>Welcome to Keepr™</h1>
    <keepForm></keepForm>
  </div>
</template>

<script>
  import KeepForm from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepForm.vue"
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getKeeps")
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    components: {
      KeepForm
    }
  };
</script>