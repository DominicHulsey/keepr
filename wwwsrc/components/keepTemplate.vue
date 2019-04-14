<template>
  <drag :transfer-data="keep"
    :class="$mq | mq({xxs: 'col-12 border shadow-sm',xs: 'col-6 border shadow-sm', sm: 'col-4 border shadow-sm', md: 'col-4 border shadow-sm', lg: 'col-3 border shadow-sm'})">
    <h3 style="font-weight:bold;text-decoration: underline;">{{keep.name}}</h3
      style="font-weight:bold;text-decoration: underline;">
    <h4>{{keep.description}}</h4>
    <img class="img-fluid sizing" :src="keep.img" />
    <div class="row justify-content-around mt-2">
      <p class="p-2 px-3 bg-primary text-white" id="keepButtons"><i class="fas fa-eye"></i> {{keep.views}}</p>
      <p class="p-2 px-3 bg-primary text-white" id="keepButtons"><i class="fas fa-map-pin"></i> {{keep.keeps}}</p>
      <p class="p-2 px-3 bg-primary text-white" id="keepButtons"><i class="fas fa-share-square"></i> {{keep.shares}}
      </p>
    </div>
    <button class="btn btn-outline-danger mb-3" @click="deleteKeep(keep.id)">Delete</button>
    </div>
  </drag>
</template>


<script>
  export default {
    name: 'keepTemplate',
    props: ["keep"],
    data() {
      return {}
    },
    computed: {


    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      }

    },
    components: {}
  }
</script>


<style scoped>
  #keepButtons {
    transition: all 0.1s linear;
  }

  #keepButtons:hover {
    box-shadow: 2px 2px 5px black;
    background-color: #60a7f4 !important;
    transform: scale(1.02);
    cursor: pointer;
  }

  .sizing {
    max-width: 100%;
  }

  #keepButtons:active {
    box-shadow: none;
    background-color: #007bff !important;
    transform: scale(1);
  }
</style>